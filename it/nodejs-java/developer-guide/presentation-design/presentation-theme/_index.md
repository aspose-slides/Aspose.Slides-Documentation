---
title: Gestire i temi della presentazione in JavaScript
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/nodejs-java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Impostare tema
- Modificare tema
- Gestire tema
- Colore del tema
- Tavolozza aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- Presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i temi master delle presentazioni in JavaScript con Aspose.Slides per Node.js per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così un cambiamento del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getmastertheme/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterthememanager/), mentre un layout o una diapositiva individuale può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseoverridethememanager/). In pratica, il tema effettivo per una diapositiva è risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sui temi: ispezionare un tema, cambiare colori e caratteri, copiare o applicare un tema, aggiornare stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un Tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formati del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mastertheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna perché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le principali proprietà del tema e segnala quante stili di sfondo, riempimento, linea ed effetto sono memorizzati nel tema:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro sul tema effettivo mostrato più avanti in questo articolo quando potrebbero essere presenti sovrascritture di layout o di diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nello [ColorScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/colorscheme/), tutti gli oggetti che ancora fanno riferimento a quel colore del tema sono risolti rispetto al nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end-to-end seguente crea una forma che usa `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo il cambiamento del tema. Se sostituisci il colore dello schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Utilizzare i Colori dalla Tavolozza Aggiuntiva**

PowerPoint deriva varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite l'enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.

**2** - Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `Accent4`.

### **Mappare i Valori `SchemeColor` agli Slot `ColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre lo [ColorScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/colorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La corrispondenza è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set principale di caratteri per i titoli e un set secondario per il corpo del testo. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontscheme/) espongono tali set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` - Carattere Corpo Latin (Minor Latin Font)
* `+mj-lt` - Carattere Titolo Latin (Major Latin Font)
* `+mn-ea` - Carattere Corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Carattere Titolo East Asian (Major East Asian Font)

L'esempio seguente crea un titolo che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario del tema. Quindi cambia i caratteri del tema e salva il risultato:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il titolo segue il carattere principale e il testo del corpo segue il carattere secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema varia.

{{% alert color="info" title="Tip" %}}

Per ulteriori informazioni sui caratteri delle presentazioni, vedere [PowerPoint Fonts](/slides/it/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Copiare o Applicare un Tema**

Ci sono due flussi di lavoro comuni, e risolvono problemi diversi.

### **Preservare un Tema di Origine Quando Si Spostano Diapositive**

Se desideri spostare una diapositiva in un'altra presentazione preservandone il design originale, clona il master di origine nella presentazione di destinazione con [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslidecollection/), quindi clona la diapositiva con [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) e il master clonato. Questo trasferisce il master, i suoi layout e il tema associato insieme.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Questo è il flusso di lavoro consigliato quando la diapositiva di origine deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare i colori, i caratteri, gli sfondi e gli effetti guidati dal tema.

### **Applicare i Valori del Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/overridetheme/) copiano i tre componenti principali del tema nella sovrascrittura.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Questo cambia il tema usato da quella diapositiva senza modificare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/overridetheme/).

### **Applicare una Sovrascrittura del Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva specifica non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per eccezioni reali. Sovrascritture a livello di diapositiva eccessive rendono più difficile prevedere i cambiamenti globali del tema in seguito.

## **Aggiornare gli Stili di Sfondo del Tema**

Gli riempimenti di sfondo del tema sono memorizzati in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/formatscheme/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento fisicamente archiviate in questa collezione perché l'interfaccia può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di utilizzare uno stile di sfondo, ispeziona la collezione memorizzata e l'attuale [Background.getStyleIndex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/background/). Un indice di stile pari a `0` significa nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo del tema. Questo è diverso dall'indicizzare direttamente la collezione JavaScript, dove l'indice `0` indica il primo elemento memorizzato. Non dare per scontato che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato visibile dipende dall'entrata del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva usa il proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/background/) quando devi conoscere lo sfondo finale dopo l'applicazione dell'ereditarietà.

{{% alert color="warning" title="Warning" %}}

Non trattare l'indice di stile come un indice di collezione a base zero. Evita anche di codificare hard-coded un numero di stile da un file e assumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/nodejs-java/presentation-background/).

{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formati del tema contiene collezioni separate di riempimento, linea ed effetti esposte tramite [FormatScheme.getFillStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/formatscheme/), e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/formatscheme/). I temi Office tipici contengono spesso tre voci di stile principali che corrispondono visivamente a formattazioni sottili, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione anziché assumere un conteggio fisso.

![Effetti del tema sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in JavaScript, l'indice della collezione è a base zero: l'indice `0` è il primo stile memorizzato e l'indice `2` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [ShapeStyle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta potrebbero rimanere inalterate.

L'esempio seguente verifica che le voci di stile richieste esistano, modifica il primo stile di linea, modifica il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un'ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende ancora da quali slot di stile ogni forma fa riferimento e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica delle impostazioni di linea, riempimento e ombra](presentation-design_11.png)

## **Leggere i Valori del Tema Effettivi**

Gli oggetti tema grezzi ti dicono cosa è definito a un determinato livello. I valori effettivi ti dicono cosa una diapositiva o una forma usa realmente dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseoverridethememanager/). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/background/), e per un riempimento, usa [FillFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Usa i dati effettivi per diagnosi di rendering, validazione e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getmastertheme/), potresti perdere un master, layout, diapositiva o sovrascrittura di forma che cambia l'aspetto finale.

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidethememanager/) della diapositiva e inizializza il suo tema di sovrascrittura. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva preservandone l'aspetto di origine, clona il master di origine nella destinazione e clona la diapositiva con quel master usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslidecollection/) e [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/). Questo mantiene insieme il master, i layout e il tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseoverridethememanager/) per un tema di diapositiva o layout e i metodi di dati effettivi corrispondenti per gli oggetti di formato come [Background.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/). Queste API restituiscono i valori risolti dopo l'applicazione di ereditarietà e sovrascritture.