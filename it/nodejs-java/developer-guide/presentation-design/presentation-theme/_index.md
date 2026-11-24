---
title: Gestire i temi della presentazione in JavaScript
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/nodejs-java/presentation-theme/
keywords:
- Tema PowerPoint
- tema della presentazione
- tema della diapositiva
- imposta tema
- cambia tema
- gestisci tema
- tema esterno
- THMX
- colore del tema
- tavolozza aggiuntiva
- carattere del tema
- stile del tema
- effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "I temi master delle presentazioni in JavaScript con Aspose.Slides per Node.js per creare, personalizzare e convertire file PowerPoint con branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un set coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema si riferiscono a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così un cambiamento di tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), mentre un layout o una diapositiva individuale può sovrascrivere il suo tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). In pratica, il tema effettivo per una diapositiva è risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni legati al tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Esaminare un Tema**

L’oggetto [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formati del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L’esempio seguente legge le proprietà principali del tema e riporta quante impostazioni di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

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

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Esamina il master associato alla diapositiva e usa il flusso di lavoro sul tema effettivo mostrato più avanti in questo articolo quando possono essere presenti sovrascritture di layout o di diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono riferirsi a un colore logico della [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) enumerazione. Quando cambi la voce corrispondente nella [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/), tutti gli oggetti che ancora fanno riferimento a quel colore del tema sono risolti contro il nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L’esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

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

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se sostituisci il colore della tavolozza con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Usare i Colori dalla Tavolozza Aggiuntiva**

PowerPoint deriva varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite la [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) enumerazione.

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** – Colori principali del tema.

**2** – Varianti più chiare e più scure prodotte dai colori principali del tema.

L’esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

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

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore di `Accent4`.

### **Mappare i Valori di `SchemeColor` agli Slot di `ColorScheme`**

La enumerazione [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre la [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all’altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set di caratteri principale per le intestazioni e un set minore per il corpo del testo. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) espongono tali set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn‑lt` – Carattere del corpo Latin (Minor Latin Font)
* `+mj‑lt` – Carattere dell’intestazione Latin (Major Latin Font)
* `+mn‑ea` – Carattere del corpo East Asian (Minor East Asian Font)
* `+mj‑ea` – Carattere dell’intestazione East Asian (Major East Asian Font)
* `+mn‑cs` – Carattere del corpo Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Carattere dell’intestazione Complex Script (Major Complex Script Font)

L’esempio seguente crea un’intestazione che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin minore del tema. Cambia quindi i caratteri del tema e salva il risultato:

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

L’intestazione segue il carattere principale e il testo del corpo segue il carattere minore. Un testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema cambia.

Le collezioni di caratteri principali e minori possono anche contenere mappature di caratteri per sistemi di scrittura individuali, come cirillico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Script-Specific Theme Fonts](/slides/it/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Suggerimento" %}}

Per ulteriori informazioni sui caratteri della presentazione, vedere [PowerPoint Fonts](/slides/it/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

### **Risolvere i Riferimenti ai Caratteri del Tema**

Durante l’ispezione del testo, [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) può restituire un riferimento al tema come `+mn‑lt` invece di un nome di famiglia di caratteri. Chiama [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) con il tema effettivo appropriato per risolvere quel riferimento. I prefissi `+mj` e `+mn` selezionano i set di caratteri principali e minori; i suffissi `-lt`, `-ea` e `-cs` selezionano i loro caratteri Latin, East Asian e Complex Script, rispettivamente.

Ottieni il tema effettivo tramite [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) sull’oggetto a cui si applica il tema del testo ispezionato. Per testo ordinario su una diapositiva, chiama questo metodo sulla diapositiva così il contesto include il tema ereditato da quella diapositiva e le sovrascritture locali. Quando si ispeziona un layout o un master, usa il suo tema effettivo. Non dare per scontato che il tema del primo master si applichi a tutte le diapositive.

L’esempio seguente crea una porzione di testo che fa esplicitamente riferimento al carattere Latin minore. Inizializza lo schema di caratteri di una diapositiva tramite [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) e imposta le famiglie Latin principali e minori su `Arial` e `Calibri`, rendendo il risultato riproducibile senza un file di input.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

L’output è `+mn‑lt -> Calibri` seguito da `Verdana -> Verdana`. Il riferimento memorizzato rimane invariato, mentre un nome di famiglia esplicito è restituito così com’è. Se la porzione avesse usato `+mj‑lt`, si sarebbe risolto in `Arial` in questo tema.

Risolvere un riferimento al tema identifica la famiglia di caratteri specificata dal tema. Non verifica la disponibilità del carattere né determina il file del carattere effettivamente usato dopo la sostituzione o il fallback dei glifi durante il rendering. Vedi [Font Selection Sequence](/slides/it/nodejs-java/font-selection-sequence/) e [Font Substitution](/slides/it/nodejs-java/font-substitution/) per questi passaggi separati.

## **Copiare o Applicare un Tema**

I flussi di lavoro seguenti risolvono diversi problemi legati al tema.

### **Applicare un Tema Esterno alle Diapositive Dipendenti da un Master**

Usa [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) quando disponi di un file tema PowerPoint (`.thmx`) e vuoi ridisegnare ogni diapositiva che dipende da un determinato master. Seleziona il master dalla collezione [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) rappresentata da [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea un nuovo master slide basato sul master selezionato.  
1. Applica il tema esterno al nuovo master.  
1. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.  
1. Restituisce il nuovo [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).

L’esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un tema non valido, corrotto o non supportato può causare [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/). Convalida i percorsi forniti dagli utenti, gestisci gli errori di accesso al file‑system e salva la presentazione solo dopo che il tema è stato applicato correttamente.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i caratteri, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema sono risolti contro il tema esterno. I colori, i caratteri, i riempimenti e le altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e diapositiva possono anche avere la precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a caratteri non disponibili nell’ambiente di runtime. Per una resa e un’esportazione coerenti, installa i caratteri richiesti, fornisci font tramite [custom font sources](/slides/it/nodejs-java/custom-font/), o configura [font substitution](/slides/it/nodejs-java/font-substitution/).

Questo è un flusso di lavoro diretto a livello di master: il metodo accetta un percorso di file `.thmx` e non richiede la creazione manuale di sovrascritture di tema a livello di layout o diapositiva.

### **Applicare Temi Esterni Differenti in una Presentazione Multi‑Master**

Quando il master pertinente non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). Conserva i riferimenti ai master originali prima di applicare qualsiasi tema perché ogni chiamata crea un nuovo master nella presentazione.

L’esempio seguente usa diapositive di due sezioni per individuare i loro master e applica un tema esterno diverso a ciascun gruppo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

La prima chiamata influisce solo sulle diapositive che dipendevano da `firstGroupMaster`, e la seconda solo su quelle che dipendevano da `secondGroupMaster`. Le diapositive appartenenti a qualsiasi altro master non vengono ridisegnate.

### **Preservare un Tema di Origine Quando si Spostano Diapositive**

Se desideri spostare una diapositiva in un’altra presentazione mantenendo il suo design originale, clona il master di origine nella presentazione di destinazione con [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), quindi clona la diapositiva con [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) e il master clonato. Questo porta con sé il master, i suoi layout e il relativo tema.

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

### **Applicare Valori del Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) copiano i tre componenti principali del tema nella sovrascrittura.

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

Questo modifica il tema usato da quella diapositiva senza cambiare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/).

### **Applicare una Sovrascrittura di Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una specifica diapositiva non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per vere eccezioni. Sovrascritture eccessive a livello di diapositiva rendono più difficile prevedere i cambiamenti globali del tema in seguito.


<!-- visual-explanation:presentation-theme:start -->
[![Un tema master alimenta due layout; una sovrascrittura del layout influisce sulle sue diapositive eccetto una diapositiva con una sovrascrittura più locale.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Una sovrascrittura del layout si applica alle diapositive che usano quel layout a meno che una diapositiva fornisca la propria sovrascrittura. I valori basati sul tema seguono lo schema risolto; gli oggetti formattati esplicitamente possono mantenere il loro aspetto locale. Mantieni le sovrascritture il più stretto possibile rispetto all’eccezione di design prevista.*
<!-- visual-explanation:presentation-theme:end -->

## **Aggiornare gli Stili di Sfondo del Tema**

I riempimenti di sfondo del tema sono memorizzati in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). PowerPoint può presentare più scelte di sfondo nella sua UI rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione perché la UI può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria di stili di sfondo PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e il valore corrente di [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). Un indice di stile pari a `0` significa nessun riempimento tematico; valori positivi sono riferimenti a stili di sfondo del tema. Questo è diverso dall’indicizzare direttamente la collezione JavaScript, dove l’indice `0` indica il primo elemento memorizzato. Non dare per scontato che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L’esempio seguente riporta il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

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

Il risultato visivo dipende dalla voce di tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva usa il proprio sfondo, modificare solo lo sfondo del master potrebbe non cambiare quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) quando devi conoscere lo sfondo finale dopo l’applicazione dell’ereditarietà.

{{% alert color="warning" title="Attenzione" %}}

Non trattare l’indice di stile come un indice di collezione a zero. Evita anche di codificare un numero di stile da un file e presumerlo identico in un altro file; le definizioni di stile del tema sono specifiche per la presentazione.

{{% /alert %}}

{{% alert color="info" title="Suggerimento" %}}

Per la formattazione diretta dello sfondo e l’ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/nodejs-java/presentation-background/).

{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formati del tema contiene collezioni separate di riempimento, linea ed effetti esposte tramite [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). I temi tipici di Office spesso contengono tre voci di stile principali che corrispondono visivamente a formattazioni subtle, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione invece di assumere un conteggio fisso.

![Effetti di tema subtle, moderate e intense applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in JavaScript, l’indice della collezione è a zero: l’indice `0` è il primo stile memorizzato e l’indice `2` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposti tramite [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere invariate.

L’esempio seguente verifica che le voci di stile richieste esistano, cambia il primo stile di linea, cambia il terzo stile di riempimento, abilita un’ombra esterna nel terzo stile di effetto e salva il risultato:

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

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido e il terzo stile di effetto ottiene un’ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende ancora da quali slot di stile ciascuna forma fa riferimento e se una formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e ombra](presentation-design_11.png)

## **Selezionare Stili di Riempimento e Linea del Tema per una Forma**

Una forma può selezionare indipendentemente il suo riempimento e il contorno tramite [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) e [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). Per entrambi i metodi, l’indice `1` seleziona la prima voce nella collezione tematica corrispondente (`get_Item(0)`), e l’indice `2` seleziona la seconda (`get_Item(1)`).

L’esempio seguente imposta due stili di riempimento (oro e azzurro cielo) e due stili di linea (blu scuro a 6 pt e rosso scuro a 12 pt) nel tema predefinito di una nuova presentazione. Salva la diapositiva in tre fasi così da poter confrontare i risultati in PowerPoint.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Stili iniziali | Cambia il contorno destro | Modifica il primo riempimento del tema |
|:---:|:---:|:---:|
| ![Rettangoli oro e azzurro cielo con contorni sottili blu scuro corrispondenti](theme-style-initial.png) | ![Il rettangolo azzurro cielo ora ha un contorno rosso scuro spesso](theme-style-line-changed.png) | ![Il rettangolo sinistro è ora verde e entrambi i contorni sono invariati](theme-style-fill-changed.png) |

Selezionare uno stile di linea diverso cambia solo il contorno del rettangolo destro. Modificare il primo riempimento del tema aggiorna ogni forma che lo utilizza. Qui, solo il rettangolo sinistro diventa verde.

Su una forma esistente, un colore di riempimento locale, un colore di linea o una larghezza di linea possono sovrascrivere quella parte dello stile del tema. Se cambiare un indice di stile non produce alcun effetto visibile, controlla la [formattazione diretta](/slides/it/nodejs-java/shape-formatting/) della forma.

## **Determinare se un Riempimento Solido Effettivo Usa un Colore del Tema**

Un riempimento può essere memorizzato direttamente su un oggetto o ereditato da un paragrafo, layout, master, stile del tema o un altro livello di formattazione. Chiama [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) per risolvere quella gerarchia in un’istantanea immutabile del riempimento effettivo. Prima controlla il valore di `getFillType`. Solo quando è `FillType.Solid` dovresti leggere le proprietà del riempimento solido.

Per un riempimento solido, `getSolidFillColor` restituisce il valore RGB finale renderizzato dopo ereditarietà, ricerca del tema e applicazione delle trasformazioni di colore. Il metodo `getSolidFillSchemeColor` restituisce lo slot logico corrispondente di [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/), come `Text1` o `Accent6`. Un valore `SchemeColor.NotDefined` indica che il riempimento solido effettivo non si basa su un colore di schema. In un flusso di lavoro dove i riempimenti sono o colori del tema o colori RGB diretti, questo valore identifica un riempimento RGB diretto.

Non usare il valore locale di [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) da solo per classificare un riempimento. Per esempio, una porzione di testo può non avere un colore di schema definito localmente, quindi il suo valore locale è `NotDefined`, mentre il suo riempimento effettivo eredita un colore del tema e si risolve in `Text1` o `Accent6`. Al contrario, `getSolidFillSchemeColor` indica quale slot logico del tema ha prodotto il colore effettivo, ma non indica se quello slot proviene dall’oggetto, dal paragrafo, dal layout, dal master o da un altro livello della gerarchia di formattazione.

L’esempio seguente carica una presentazione, controlla sia i riempimenti delle forme sia i riempimenti delle porzioni di testo, stampa ogni valore RGB finale e lo schema di colore associato, e contrassegna i riempimenti solidi che non seguiranno le modifiche del colore del tema:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Il ramo `NotDefined` fornisce un elenco di audit di riempimenti solidi che non risponderanno ai cambiamenti negli slot di colore del tema. Rivedi quegli oggetti quando una presentazione deve aderire a una nuova tavolozza di brand. Il valore RGB riportato mostra ancora l’aspetto corrente, mentre il valore di schema spiega se quell’aspetto è collegato al tema.

Gli oggetti di formato efficace sono istantanee. Dopo aver cambiato il tema della presentazione, una sovrascrittura del tema o qualsiasi formattazione ereditata, chiama nuovamente `getEffective` e leggi un nuovo oggetto di riempimento effettivo prima di comparare o segnalare i colori.

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi ti dicono cosa è definito a un determinato livello. I valori effettivi ti dicono cosa una diapositiva o forma utilizza effettivamente dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), e per un riempimento usa [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

L’esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento di forma da una diapositiva:

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

Usa i dati efficaci per diagnosi di rendering, convalida e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/), potresti perdere una sovrascrittura di master, layout, diapositiva o forma che cambia l’aspetto finale.

## **FAQ**

**L’applicazione di un tema esterno influisce su tutte le diapositive della presentazione?**

No. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master conservano i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) della diapositiva e inizializza la sua sovrascrittura del tema. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione a un’altra?**

Quando si sposta una diapositiva preservandone l’aspetto di origine, clonare il master di origine nella destinazione e clonare la diapositiva con quel master usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) e [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). Questo mantiene insieme master, layout e tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) per un tema di diapositiva o layout e i metodi di dati efficaci corrispondenti per oggetti di formato come [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). Queste API restituiscono i valori risolti dopo che ereditarietà e sovrascritture sono state applicate.