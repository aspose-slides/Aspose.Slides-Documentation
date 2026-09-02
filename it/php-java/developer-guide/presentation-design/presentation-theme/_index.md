---
title: Gestire i temi della presentazione in PHP
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/php-java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Modifica tema
- Gestisci tema
- Tema esterno
- THMX
- Colore del tema
- Tavolozza aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- Presentazione
- PHP
- Aspose.Slides
description: "Temi master delle presentazioni in Aspose.Slides per PHP tramite Java per creare, personalizzare e convertire file PowerPoint con branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise anziché memorizzare ogni proprietà visiva come valore fisso, così una modifica al tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterthememanager/), mentre un layout o una diapositiva individuale può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseoverridethememanager/). In pratica, il tema effettivo per una diapositiva viene risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo e effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispeziona un tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formattazione del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/mastertheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, perché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le principali proprietà del tema e segnala quante impostazioni di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro tema-effettivo mostrato più avanti in questo articolo quando possono essere presenti sovrascritture a livello di layout o diapositiva.

## **Modifica i colori del tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nello [ColorScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/colorscheme/), tutti gli oggetti che ancora fanno riferimento a quel colore del tema vengono risolti contro il nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se sostituisci il colore di schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Usa i colori della tavolozza aggiuntiva**

PowerPoint deriva varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite l'enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/php-java/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.

**2** - Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore di `Accent4`.

### **Mappa i valori `SchemeColor` agli slot `ColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre lo [ColorScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/colorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Si tratta di nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modifica i caratteri del tema**

Uno schema di caratteri del tema contiene un set di caratteri principale per le intestazioni e un set secondario per il corpo del testo. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontscheme/) espongono questi set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` - Carattere corpo Latin (Minor Latin Font)
* `+mj-lt` - Carattere intestazione Latin (Major Latin Font)
* `+mn-ea` - Carattere corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Carattere intestazione East Asian (Major East Asian Font)

L'esempio seguente crea un'intestazione che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario del tema. Poi modifica i caratteri del tema e salva il risultato:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'intestazione segue il carattere principale e il testo del corpo segue quello secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema cambia.

Le collezioni di caratteri principale e secondario possono contenere anche mappature di caratteri per sistemi di scrittura individuali, come cirillico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedi [Script-Specific Theme Fonts](/slides/it/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Per ulteriori informazioni sui caratteri della presentazione, consulta [PowerPoint Fonts](/slides/it/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Copia o applica un tema**

I flussi di lavoro seguenti risolvono diversi problemi legati al tema.

### **Applica un tema esterno alle diapositive dipendenti da un master**

Usa [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) quando hai un file tema di PowerPoint (`.thmx`) e vuoi ridisegnare ogni diapositiva che dipende da un master specifico. Seleziona il master dalla collezione [Presentation::getMasters](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), rappresentata da [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea una nuova diapositiva master basata sul master selezionato.  
1. Applica il tema esterno al nuovo master.  
1. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.  
1. Restituisce il nuovo [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/).

L'esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un tema non valido, corrotto o non supportato può generare [PptxReadException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxreadexception/). Convalida i percorsi forniti dagli utenti, gestisci i fallimenti di accesso al file system e salva la presentazione solo dopo che il tema è stato applicato correttamente.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i caratteri, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema sono risolti rispetto al tema esterno. I colori, i caratteri, i riempimenti e altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e di diapositiva possono anche avere precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a caratteri non disponibili nell'ambiente di runtime. Per una resa e un'esportazione coerenti, installa i caratteri richiesti, fornisci loro font personalizzati [/slides/it/php-java/custom-font/], o configura la [sostituzione dei caratteri](/slides/it/php-java/font-substitution/).

Questo è un flusso di lavoro a livello di master: il metodo accetta un percorso a un file `.thmx` e non richiede la creazione manuale di sovrascritture di tema a livello di layout o diapositiva.

### **Applica temi esterni diversi in una presentazione con più master**

Quando il master rilevante non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [Slide::getLayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/) e [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/). Conserva i riferimenti ai master originali prima di applicare temi, perché ogni chiamata crea un nuovo master nella presentazione.

L'esempio seguente usa diapositive di due sezioni per individuare i loro master e applica un tema esterno diverso a ciascun gruppo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

La prima chiamata influisce solo sulle diapositive che dipendevano da `$firstGroupMaster`, e la seconda chiamata influisce solo su quelle che dipendevano da `$secondGroupMaster`. Le diapositive appartenenti a qualsiasi altro master non vengono ridisegnate.

### **Preserva un tema sorgente quando sposti le diapositive**

Se desideri spostare una diapositiva in un'altra presentazione e mantenere il suo design originale, clona il master sorgente nella presentazione di destinazione con [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/), quindi clona la diapositiva con [SlideCollection.addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) e il master clonato. Questo trasporta insieme il master, i suoi layout e il tema associato.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

È il flusso di lavoro consigliato quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare colori, caratteri, sfondi ed effetti guidati dal tema.

### **Applica valori di tema a una diapositiva esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema sorgente. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/overridetheme/) copiano i tre componenti principali del tema nella sovrascrittura.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Questo modifica il tema usato da quella diapositiva senza alterare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/overridetheme/).

### **Applica una sovrascrittura di tema a un layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva specifica non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Usa un tema a livello di master o presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per eccezioni reali. Un uso eccessivo di sovrascritture a livello di diapositiva rende più difficile prevedere i cambiamenti globali del tema.

## **Aggiorna gli stili di sfondo del tema**

I riempimenti di sfondo del tema sono memorizzati in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/formatscheme/). PowerPoint può presentare più scelte di sfondo nella sua UI rispetto al numero di definizioni di riempimento fisicamente memorizzate in questa collezione, perché la UI può combinare riempimenti di tema con colori di tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e l'indice di stile corrente tramite [Background.getStyleIndex](https://reference.aspose.com/slides/it/php-java/aspose.slides/background/). Un indice di stile pari a `0` indica nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall'indicizzazione diretta della collezione PHP, dove `get_Item(0)` indica il primo elemento memorizzato. Non assumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato visibile dipende dall'entrata del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza il proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/background/) quando hai bisogno di conoscere lo sfondo finale dopo l'applicazione dell'ereditarietà.

{{% alert color="warning" title="Warning" %}}
Non trattare l'indice di stile come un indice di collezione a base zero. Inoltre evita di codificare in modo rigido un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedi [Presentation Background](/slides/it/php-java/presentation-background/).
{{% /alert %}}

## **Aggiorna gli effetti del tema**

Uno schema di formattazione del tema contiene collezioni separate di riempimento, linea ed effetti esposte tramite [FormatScheme.getFillStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/formatscheme/) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/formatscheme/). I temi tipici di Office spesso contengono tre voci di stile principali che corrispondono visivamente a formattazioni subdole, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione invece di assumere un conteggio fisso.

![Effetti tematici subdoli, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in PHP, l'indice della collezione è a base zero: `get_Item(0)` è il primo stile memorizzato e `get_Item(2)` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [ShapeStyle](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere invariate.

L'esempio seguente verifica che le voci di stile richieste esistano, modifica il primo stile di linea, modifica il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido e il terzo stile di effetto ottiene un'ombra esterna con distanza di 10 punti. Il risultato visivo esatto dipende comunque da quali slot di stile ogni forma fa riferimento e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e ombra](presentation-design_11.png)

## **Leggi i valori effettivi del tema**

Gli oggetti tema grezzi indicano cosa è definito a un determinato livello. I valori effettivi indicano cosa una diapositiva o una forma utilizza realmente dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseoverridethememanager/). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/background/), e per un riempimento, usa [FillFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/).

L'esempio seguente legge il tema effettivo, lo sfondo e il riempimento della prima forma da una diapositiva:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Usa i dati effettivi per diagnosi di rendering, convalida e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), potresti perdere una sovrascrizione di master, layout, diapositiva o forma che modifica l'aspetto finale.

## **FAQ**

**L'applicazione di un tema esterno influisce su ogni diapositiva della presentazione?**

No. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master conservano i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidethememanager/) della diapositiva e inizializza il suo tema di sovrascrittura. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi attuali.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva e preservi il suo aspetto originale, clona il master sorgente nella destinazione e clona la diapositiva con quel master usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/) e [SlideCollection.addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/). Questo mantiene insieme master, layout e tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseoverridethememanager/) per una diapositiva o un tema di layout e i metodi corrispondenti di dati effettivi per oggetti di formato, come [Background.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/). Queste API restituiscono i valori risolti dopo l'applicazione di ereditarietà e sovrascritture.