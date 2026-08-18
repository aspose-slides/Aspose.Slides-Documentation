---
title: Gestire i temi di presentazione su Android
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/androidjava/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Modifica tema
- Gestisci tema
- Colore del tema
- Palette aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Temi di presentazione master in Aspose.Slides per Android via Java per creare, personalizzare e convertire file PowerPoint con branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise anziché memorizzare ogni proprietà visiva come valore fisso, così una modifica del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterthememanager/), mentre un layout o una diapositiva individuale può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseoverridethememanager/). In pratica, il tema effettivo per una diapositiva viene risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un Tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formato del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mastertheme/), e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mastertheme/). Ispezionare queste raccolte prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

Il seguente esempio legge le proprietà principali del tema e segnala quante sono le voci di sfondo, riempimento, linea ed effetti memorizzate nel tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Se un file utilizza più master, non presumere che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro del tema effettivo mostrato più avanti in questo articolo quando possono essere presenti sovrascritture di layout o diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/schemecolor/). Quando si modifica la voce corrispondente in [IColorScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icolorscheme/), tutti gli oggetti che fanno ancora riferimento a quel colore del tema vengono risolti con il nuovo valore. Gli oggetti che utilizzano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

Il seguente esempio end-to-end crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se si sostituisce il colore di schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Utilizzare i Colori della Palette Aggiuntiva**

PowerPoint deriva varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite l'enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla palette aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.

**2** - Varianti più chiare e più scure generate dai colori principali del tema.

Il seguente esempio crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

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

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore di `Accent4`.

### **Mappare i Valori `SchemeColor` agli Slot `IColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre [IColorScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icolorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set di caratteri principali per le intestazioni e un set di caratteri secondari per il corpo del testo. I metodi [IFontScheme.getMajor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontscheme/) espongono quei set.

PowerPoint‑compatible theme font identifiers can be used in text formatting:

* `+mn-lt` - Carattere del corpo Latin (Carattere Latin Minore)
* `+mj-lt` - Carattere intestazione Latin (Carattere Latin Maggiore)
* `+mn-ea` - Carattere del corpo East Asian (Carattere East Asian Minore)
* `+mj-ea` - Carattere intestazione East Asian (Carattere East Asian Maggiore)

Il seguente esempio crea un'intestazione che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario del tema. Poi modifica i caratteri del tema e salva il risultato:

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

L'intestazione utilizza il carattere principale e il testo del corpo utilizza il carattere secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema di caratteri del tema viene modificato.

{{% alert color="info" title="Tip" %}}
Per ulteriori informazioni sui caratteri delle presentazioni, vedere [PowerPoint Fonts](/slides/it/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o Applicare un Tema**

Esistono due flussi di lavoro comuni, e risolvono problemi diversi.

### **Preservare un Tema Sorgente Quando Si Spostano Diapositive**

Se vuoi spostare una diapositiva in un'altra presentazione e preservare il suo design originale, clona il master sorgente nella presentazione di destinazione con [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/), poi clona la diapositiva con [ISlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/) e il master clonato. Questo trasporta il master, i suoi layout e il tema associato insieme.

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

Questo è il flusso di lavoro preferito quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare colori, caratteri, sfondi ed effetti guidati dal tema.

### **Applicare i Valori del Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema sorgente. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/overridetheme/), e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/overridetheme/) copiano i tre componenti principali del tema nella sovrascrittura.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Questo modifica il tema usato da quella diapositiva senza alterare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/overridetheme/).

### **Applicare una Sovrascrittura del Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che utilizzano quel layout, a meno che una diapositiva specifica non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Utilizza un tema a livello di master o presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per vere eccezioni. Troppe sovrascritture a livello di diapositiva rendono più difficili da prevedere le successive modifiche globali del tema.

## **Aggiornare gli Stili di Sfondo del Tema**

I riempimenti di sfondo del tema sono memorizzati in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iformatscheme/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa raccolta, poiché l'interfaccia può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria degli stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di utilizzare uno stile di sfondo, ispeziona la raccolta memorizzata e l'attuale [Background.getStyleIndex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/background/). Un indice di stile pari a `0` significa nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall'indicizzare direttamente la collezione Java, dove `get_Item(0)` indica il primo elemento memorizzato. Non presumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

Il seguente esempio segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

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

Il risultato visibile dipende dalla voce del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza il proprio sfondo, modificare solo lo sfondo del master potrebbe non modificare quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/background/) quando hai bisogno di conoscere lo sfondo finale dopo che è stata applicata l'ereditarietà.

{{% alert color="warning" title="Warning" %}}
Non trattare l'indice di stile come un indice di raccolta basato su zero. Evita inoltre di codificare rigidamente un numero di stile da un file e presumere che abbia la stessa apparenza in un altro file; le definizioni degli stili del tema sono specifiche per la presentazione.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/androidjava/presentation-background/).
{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formato del tema contiene collezioni separate di stili di riempimento, linea ed effetto esposte tramite [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iformatscheme/), e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iformatscheme/). I temi tipici di Office spesso contengono tre voci principali di stile che corrispondono visivamente a formattazioni sottili, moderate e intense, ma il codice dovrebbe ispezionare ogni collezione invece di presumere un conteggio fisso.

![Effetti del tema sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in Java, l'indice della collezione parte da zero: `get_Item(0)` è il primo stile memorizzato e `get_Item(2)` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [IShapeStyle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere inalterate.

Il seguente esempio verifica che le voci di stile richieste esistano, modifica il primo stile di linea, modifica il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un'ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende ancora da quali slot di stile ogni forma fa riferimento e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica delle impostazioni di linea, riempimento e ombra](presentation-design_11.png)

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi indicano cosa è definito a un certo livello. I valori effettivi indicano cosa una diapositiva o una forma utilizza realmente dopo che l'ereditarietà e le sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseoverridethememanager/). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/background/), e per un riempimento, usa [FillFormat.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/).

Il seguente esempio legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Utilizza i dati effettivi per diagnosi di rendering, convalide e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/), potresti perdere una sovrascrittura di master, layout, diapositiva o forma che modifica l'aspetto finale.

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidethememanager/) della diapositiva e inizializza il suo tema di sovrascrittura. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva preservandone l'aspetto di origine, clona il master sorgente nella destinazione e clona la diapositiva con quel master usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/). Questo mantiene insieme il master, i layout e il tema.

**Come posso vedere i valori effettivi dopo l'ereditarietà e le sovrascritture?**

Utilizza [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseoverridethememanager/) per un tema di diapositiva o layout e i metodi corrispondenti di dati effettivi per gli oggetti di formato, come [Background.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/). queste API restituiscono i valori risolti dopo l'applicazione dell'ereditarietà e delle sovrascritture.