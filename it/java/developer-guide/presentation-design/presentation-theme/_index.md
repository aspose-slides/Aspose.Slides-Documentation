---
title: Gestire i temi delle presentazioni in Java
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/java/presentation-theme/
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
- palette aggiuntiva
- font del tema
- stile del tema
- effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i temi master delle presentazioni in Aspose.Slides per Java per creare, personalizzare e convertire file PowerPoint con un'identità di marca coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti consapevoli del tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così un cambiamento di tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterthememanager/), mentre un layout o una diapositiva individuale può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseoverridethememanager/). In pratica, il tema effettivo per una diapositiva viene risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono stati risolti.

## **Ispezionare un Tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formati del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/mastertheme/). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e segnala quante stilizzazioni di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Se un file utilizza più master, non assumere che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro sul tema effettivo mostrato più avanti in questo articolo quando potrebbero essere presenti sovrascritture di layout o diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dalla enumerazione [SchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/schemecolor/). Quando si modifica la voce corrispondente in [IColorScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/icolorscheme/), tutti gli oggetti che ancora fanno riferimento a quel colore del tema vengono risolti rispetto al nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo il cambio del tema. Se si sostituisce il colore di schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Utilizzare i Colori dalla Palette Aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite la enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/java/com.aspose.slides/colortransformoperation/).

![Colori principali del tema e varianti più chiare e più scure generate dalla palette aggiuntiva](additional-palette-colors.png)

**1** – Colori principali del tema.

**2** – Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `Accent4`.

### **Mappare i Valori `SchemeColor` negli Slot `IColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre [IColorScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/icolorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i Font del Tema**

Uno schema di font del tema contiene un set di font principale per le intestazioni e un set di font secondario per il corpo del testo. I metodi [IFontScheme.getMajor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontscheme/) espongono questi set.

Gli identificatori di font del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` – Font del corpo Latin (Minor Latin Font)
* `+mj-lt` – Font dell’intestazione Latin (Major Latin Font)
* `+mn-ea` – Font del corpo East Asian (Minor East Asian Font)
* `+mj-ea` – Font dell’intestazione East Asian (Major East Asian Font)

L'esempio seguente crea un’intestazione che utilizza il font Latin principale del tema e una riga di corpo che utilizza il font Latin secondario del tema. Quindi cambia i font del tema e salva il risultato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’intestazione segue il font principale e il testo del corpo segue il font secondario. Il testo che ha un nome di font esplicito anziché un identificatore del tema non cambierà automaticamente quando lo schema di font del tema varia.

Le raccolte di font principali e secondari possono contenere anche mappature di font per sistemi di scrittura individuali, come cirillico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Script‑Specific Theme Fonts](/slides/it/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Per ulteriori informazioni sui font delle presentazioni, vedere [PowerPoint Fonts](/slides/it/java/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o Applicare un Tema**

I flussi di lavoro seguenti risolvono problemi diversi legati al tema.

### **Applicare un Tema Esterno alle Diapositive Dipendenti da un Master**

Usa [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) quando disponi di un file tema PowerPoint (`.thmx`) e desideri ridefinire lo stile di tutte le diapositive che dipendono da un master specifico. Seleziona il master dalla collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea un nuovo master slide basato sul master selezionato.
1. Applica il tema esterno al nuovo master.
1. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.
1. Restituisce il nuovo oggetto [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/).

L'esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un tema non valido, corrotto o non supportato può causare [PptxReadException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxreadexception/). Convalida i percorsi forniti dagli utenti, gestisci i fallimenti di accesso al file system e salva la presentazione solo dopo che il tema è stato applicato correttamente.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i font, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema vengono risolti rispetto al tema esterno. I colori, i font, i riempimenti e altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e di diapositiva possono anche avere precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a font non disponibili nell’ambiente di runtime. Per una resa ed esportazione coerenti, installa i font richiesti, fornisci font tramite [custom font sources](/slides/it/java/custom-font/), o configura la [font substitution](/slides/it/java/font-substitution/).

Questo è un flusso di lavoro diretto a livello di master: il metodo accetta un percorso a un file `.thmx` e non richiede la creazione manuale di sovrascritture di tema a livello di diapositiva o layout.

### **Applicare Temi Esterni Diversi in una Presentazione Multi‑Master**

Quando il master rilevante non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/). Conserva i riferimenti ai master originali prima di applicare i temi, poiché ogni chiamata crea un nuovo master nella presentazione.

L'esempio seguente utilizza diapositive di due sezioni per individuare i rispettivi master e applica un tema esterno diverso a ciascun gruppo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

La prima chiamata interessa solo le diapositive che dipendevano da `firstGroupMaster`, e la seconda solo le diapositive che dipendevano da `secondGroupMaster`. Le diapositive appartenenti a qualsiasi altro master non vengono ridefinite.

### **Conservare un Tema di Origine Durante lo Spostamento delle Diapositive**

Se vuoi spostare una diapositiva in un’altra presentazione e conservare il suo design originale, clona il master di origine nella presentazione di destinazione con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/), quindi clona la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/) e il master clonato. In questo modo il master, i layout e il tema associato vengono trasferiti insieme.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Questo è il flusso di lavoro consigliato quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare colori, font, sfondi ed effetti guidati dal tema.

### **Applicare Valori di Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/overridetheme/) copiano i tre componenti principali del tema nella sovrascrittura.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Questo modifica il tema usato da quella diapositiva senza alterare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/overridetheme/).

### **Applicare una Sovrascrittura di Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva specifica non abbia una propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout richiede uno stile diverso, e una sovrascrittura di diapositiva solo per vere eccezioni. Un eccesso di sovrascritture a livello di diapositiva rende più difficile prevedere i cambiamenti di tema globali successivi.

## **Aggiornare gli Stili di Sfondo del Tema**

Gli sfondi del tema sono memorizzati in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/iformatscheme/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione, poiché l’interfaccia può combinare riempimenti di tema con colori di tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e l’attuale indice di stile ottenuto con [Background.getStyleIndex](https://reference.aspose.com/slides/it/java/com.aspose.slides/background/). Un indice di stile pari a `0` indica nessun riempimento tematico; valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall’indicizzazione diretta della collezione Java, dove `get_Item(0)` indica il primo elemento memorizzato. Non assumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato visivo dipende dalla voce del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza il proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/background/) quando hai bisogno di conoscere lo sfondo finale dopo l’applicazione dell’eredità.

{{% alert color="warning" title="Warning" %}}
Non trattare l’indice di stile come un indice di collezione basato su zero. Evita inoltre di codificare un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Per la formattazione diretta dello sfondo e l’eredità dello sfondo, vedere [Presentation Background](/slides/it/java/presentation-background/).
{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formati del tema contiene collezioni separate di riempimento, linea ed effetti esposte tramite [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/iformatscheme/) e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/iformatscheme/). I temi tipici di Office spesso contengono tre voci di stile principali che corrispondono visivamente a formattazioni sottile, moderata e intensa, ma il codice dovrebbe ispezionare ogni collezione invece di assumere un conteggio fisso.

![Effetti del tema sottile, moderato e intenso applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in Java, l’indice della collezione è basato su zero: `get_Item(0)` è il primo stile memorizzato e `get_Item(2)` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [IShapeStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che lo riferiscono; le forme con formattazione diretta possono rimanere inalterate.

L'esempio seguente verifica che le voci di stile richieste esistano, cambia il primo stile di linea, cambia il terzo stile di riempimento, abilita un’ombra esterna nel terzo stile di effetto e salva il risultato:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un’ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende comunque da quali slot di stile fa riferimento ciascuna forma e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e ombra](presentation-design_11.png)

## **Determinare se un Riempimento Solido Effettivo Usa un Colore del Tema**

Un riempimento può essere memorizzato direttamente su un oggetto o ereditato da un paragrafo, layout, master, stile del tema o un altro livello di formattazione. Chiamare [IFillFormat.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformat/) per risolvere quella gerarchia in un oggetto immutabile [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformateffectivedata/). Prima controlla [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformateffectivedata/). Solo quando è `FillType.Solid` dovresti leggere le proprietà del riempimento solido.

Per un riempimento solido, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformateffectivedata/) restituisce il valore RGB finale renderizzato dopo ereditarietà, ricerca del tema e trasformazioni di colore. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformateffectivedata/) restituisce lo slot logico corrispondente di [SchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/schemecolor/), ad esempio `Text1` o `Accent6`. Un valore `SchemeColor.NotDefined` indica che il riempimento solido effettivo non è basato su uno slot di schema. In un flusso di lavoro dove i riempimenti sono o colori del tema o colori RGB diretti, questo valore identifica un riempimento RGB diretto.

Non usare il valore locale di [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/icolorformat/) da solo per classificare un riempimento. Per esempio, una porzione di testo può non avere un colore di schema definito localmente, quindi il suo valore locale è `NotDefined`, mentre il suo riempimento effettivo eredita un colore del tema e risolve a `Text1` o `Accent6`. Al contrario, `getSolidFillSchemeColor` indica quale slot logico del tema ha prodotto il colore effettivo, ma non dice se quello slot provenga dall’oggetto, dal paragrafo, dal layout, dal master o da un altro livello della gerarchia.

L'esempio seguente carica una presentazione, verifica i riempimenti di forme e di porzioni di testo, stampa ogni valore RGB finale e lo schema colore associato, e segna i riempimenti solidi che non seguiranno le modifiche ai colori del tema:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Il ramo `NotDefined` fornisce un elenco di audit di riempimenti solidi che non risponderanno ai cambiamenti negli slot di colore del tema. Rivedi quegli oggetti quando una presentazione deve aderire a una nuova palette di brand. Il valore RGB riportato mostra comunque l’aspetto attuale, mentre il valore dello schema spiega se quell’aspetto è collegato al tema.

Gli oggetti di formato effettivo sono snapshot. Dopo aver cambiato il tema della presentazione, una sovrascrittura del tema o qualsiasi formattazione ereditata, chiama nuovamente `getEffective` e leggi un nuovo oggetto `IFillFormatEffectiveData` prima di confrontare o segnalare i colori.

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi indicano cosa è definito a un determinato livello. I valori effettivi indicano cosa usa realmente una diapositiva o una forma dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseoverridethememanager/). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/background/), e per un riempimento usa [FillFormat.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/fillformat/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento di forma da una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Usa i dati effettivi per diagnostica di rendering, convalida e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), potresti perdere un master, layout, diapositiva o sovrascrittura di forma che cambia l’aspetto finale.

## **FAQ**

**L'applicazione di un tema esterno influisce su ogni diapositiva della presentazione?**

No. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master mantengono i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidethememanager/) della diapositiva e inizializza la sua sovrascrittura di tema. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi attuali.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva e ne conservi l’aspetto di origine, clona il master di origine nella destinazione e clona la diapositiva con quel master usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/). Questo mantiene insieme master, layout e tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseoverridethememanager/) per un tema di diapositiva o layout e i corrispondenti metodi di dati effettivi per oggetti di formato come [Background.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/fillformat/). Queste API restituiscono i valori risolti dopo l’applicazione di ereditarietà e sovrascritture.