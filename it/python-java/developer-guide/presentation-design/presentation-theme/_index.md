---
title: Gestire i temi delle presentazioni in Python tramite Java
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/python-java/presentation-theme/
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
- Font del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- Presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci i temi master delle presentazioni in Aspose.Slides per Python tramite Java per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, quindi una modifica del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasterTheme). Una presentazione può inoltre contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterthememanager/#getOverrideTheme), mentre un layout o una diapositiva individuale può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). In pratica, il tema efficace per una diapositiva è risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori efficaci dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/mastertheme/) espone lo schema di colori, lo schema di caratteri e lo schema di formattazione del tema tramite [MasterTheme.getColorScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/mastertheme/#getFontScheme) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/mastertheme/#getFormatScheme). Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna perché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e segnala quante vengono memorizzate le voci di stile di sfondo, riempimento, linea ed effetto nel tema:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Se un file utilizza più master, non presumere che ogni diapositiva abbia lo stesso tema efficace. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro tema‑efficace mostrato più avanti in questo articolo quando potrebbero esserci sovrascritture di layout o di diapositiva.

## **Modificare i colori del tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nello [ColorScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/colorscheme/), tutti gli oggetti che ancora fanno riferimento a quel colore del tema vengono risolti rispetto al nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento efficace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se sostituisci il colore di schema con un colore diretto sulla forma, le successive modifiche a `Accent4` non influenzeranno più quel riempimento.

### **Usare i colori dalla tavolozza aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite l'enumerazione [ColorTransformOperation](https://reference.aspose.com/slides/it/python-java/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.  
**2** - Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati a partire dal nuovo valore di `Accent4`.

### **Mappare i valori `SchemeColor` agli slot `ColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre lo [ColorScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/colorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i font del tema**

Uno schema di font del tema contiene un set di font principali per le intestazioni e un set di font secondari per il corpo del testo. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontscheme/#getMajor) e [FontScheme.getMinor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontscheme/#getMinor) espongono questi set.

Gli identificatori di font del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn‑lt` - Font del corpo Latin (Font Latin Minore)
* `+mj‑lt` - Font dell'intestazione Latin (Font Latin Maggiore)
* `+mn‑ea` - Font del corpo East Asian (Font East Asian Minore)
* `+mj‑ea` - Font dell'intestazione East Asian (Font East Asian Maggiore)

L'esempio seguente crea un'intestazione che utilizza il font Latin principale del tema e una riga di corpo che utilizza il font Latin secondario del tema. Poi cambia i font del tema e salva il risultato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'intestazione segue il font principale e il testo del corpo segue il font secondario. Un testo che ha un nome di font esplicito invece di un identificatore del tema non verrà cambiato automaticamente quando lo schema di font del tema cambia.

Le collezioni di font principali e secondari possono anche contenere mappature di font per sistemi di scrittura individuali, come Cyrillico, Arabo, Giapponese, Georgiano e Thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Font del tema specifici per script](/slides/it/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Suggerimento" %}}
Per ulteriori informazioni sui font delle presentazioni, vedere [Font di PowerPoint](/slides/it/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o applicare un tema**

I flussi di lavoro seguenti risolvono diversi problemi relativi al tema.

### **Applicare un tema esterno alle diapositive dipendenti da un master**

Usa [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) quando hai un file tema PowerPoint (`.thmx`) e vuoi ridefinire lo stile di ogni diapositiva che dipende da un master specifico. Seleziona il master dalla collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters), rappresentata da [MasterSlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea un nuovo master slide basato sul master selezionato.  
2. Applica il tema esterno al nuovo master.  
3. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.  
4. Restituisce il nuovo [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/).

L'esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master e salva la presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un tema non valido, corrotto o non supportato può generare [PptxReadException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxreadexception/). Convalida i percorsi forniti dagli utenti, gestisci i fallimenti di accesso al file system e salva la presentazione solo dopo che il tema è stato applicato con successo.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i font, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema vengono risolti rispetto al tema esterno. I colori, i font, i riempimenti e altre formattazioni assegnate direttamente possono rimanere invariati. Le sovrascritture a livello di layout e di diapositiva possono anche avere la precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a font non disponibili nell'ambiente di runtime. Per una resa e un'esportazione coerenti, installa i font richiesti, forniscili tramite [font personalizzati](/slides/it/python-java/custom-font/), o configura la [sostituzione dei font](/slides/it/python-java/font-substitution/).

Questo è un flusso di lavoro diretto a livello di master: il metodo accetta il percorso di un file `.thmx` e non richiede la creazione manuale di sovrascritture di tema a livello di diapositiva o layout.

### **Applicare temi esterni diversi in una presentazione multi‑master**

Quando il master rilevante non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getMasterSlide). Conserva i riferimenti ai master originali prima di applicare qualsiasi tema perché ogni chiamata crea un altro master nella presentazione.

L'esempio seguente utilizza diapositive di due sezioni per individuare i loro master e applica un tema esterno diverso a ciascun gruppo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La prima chiamata interessa solo le diapositive che dipendevano da `first_group_master`, e la seconda chiamata interessa solo le diapositive che dipendevano da `second_group_master`. Le diapositive appartenenti a qualsiasi altro master non vengono ridefinite.

### **Preservare un tema sorgente quando si spostano diapositive**

Se vuoi spostare una diapositiva in un'altra presentazione e conservare il suo design originale, clona il master di origine nella presentazione di destinazione con [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone), quindi clona la diapositiva con [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) e il master clonato. Questo trasporta il master, i suoi layout e il tema associato insieme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Questo è il flusso di lavoro consigliato quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare i colori, i font, gli sfondi e gli effetti guidati dal tema.

### **Applicare i valori del tema a una diapositiva esistente**

Se la diapositiva target deve rimanere sul master e layout correnti, inizializza una sovrascrittura a livello di diapositiva dal tema sorgente. I metodi [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) copiano i tre componenti principali del tema nella sovrascrittura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Questo modifica il tema usato da quella diapositiva senza cambiare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/overridetheme/#clear).

### **Applicare una sovrascrittura del tema a un layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva particolare non abbia la propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout ha bisogno di uno stile diverso, e una sovrascrittura di diapositiva solo per eccezioni reali. Troppe sovrascritture a livello di diapositiva rendono più difficile prevedere le modifiche globali successive al tema.

## **Aggiornare gli stili di sfondo del tema**

Gli sfondi del tema sono memorizzati in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/it/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione perché l'interfaccia può combinare riempimenti del tema con i colori del tema e altri riferimenti di stile.

![Galleria degli stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di utilizzare uno stile di sfondo, ispeziona la collezione memorizzata e l'attuale [Background.getStyleIndex](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/#getStyleIndex). Un indice di stile pari a `0` indica nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo del tema. Questo è diverso dall'indicizzare direttamente la collezione, dove `get_Item(0)` indica il primo elemento memorizzato. Non presumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente segnala il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato visibile dipende dalla voce di tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva utilizza uno sfondo proprio, modificare solo lo sfondo del master potrebbe non influire su quella diapositiva. Usa [Background.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/#getEffective) quando hai bisogno di conoscere lo sfondo finale dopo che è stata applicata l'eredità.

{{% alert color="warning" title="Avviso" %}}
Non trattare l'indice di stile come un indice di collezione a base zero. Evita inoltre di codificare in modo rigido un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="success" title="Suggerimento" %}}
Per la formattazione diretta dello sfondo e l'eredità dello sfondo, vedere [Sfondo della presentazione](/slides/it/python-java/presentation-background/).
{{% /alert %}}

## **Aggiornare gli effetti del tema**

Uno schema di formattazione del tema contiene collezioni separate di riempimento, linea ed effetti esposte tramite [FormatScheme.getFillStyles](https://reference.aspose.com/slides/it/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/it/python-java/aspose.slides/formatscheme/#getLineStyles) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/it/python-java/aspose.slides/formatscheme/#getEffectStyles). I temi tipici di Office contengono spesso tre voci di stile principali che corrispondono visivamente a formattazioni sottili, moderate e intense, ma il codice dovrebbe ispezionare ciascuna collezione invece di presumere un conteggio fisso.

![Effetti sottili, moderati e intensi del tema applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in Python tramite Java, l'indice della collezione è a base zero: `get_Item(0)` è il primo stile memorizzato e `get_Item(2)` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [ShapeStyle](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere invariate.

L'esempio seguente verifica che le voci di stile richieste esistano, cambia il primo stile di linea, cambia il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un'ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende ancora da quali slot di stile ciascuna forma riferisce e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e impostazioni di ombra](presentation-design_11.png)

## **Determinare se un riempimento solido efficace utilizza un colore del tema**

Un riempimento può essere memorizzato direttamente su un oggetto o ereditato da un paragrafo, layout, master, stile del tema o un altro livello di formattazione. Chiama [FillFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getEffective) per risolvere tale gerarchia in dati di riempimento efficaci immutabili. Controlla prima `getFillType` sull'oggetto dei dati efficaci. Solo quando è `FillType.Solid` dovresti leggere le proprietà del riempimento solido.

Per un riempimento solido, `getSolidFillColor` restituisce il valore RGB finale dopo che sono state applicate l'eredità, la ricerca nel tema e le trasformazioni di colore. `getSolidFillSchemeColor` restituisce lo slot logico corrispondente di [SchemeColor], come `Text1` o `Accent6`. Un valore di `SchemeColor.NotDefined` indica che il riempimento solido efficace non è basato su un colore di schema. In un flusso di lavoro dove i riempimenti sono o colori del tema o colori RGB diretti, questo valore identifica un riempimento RGB diretto.

Non usare solo il valore locale di [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/colorformat/#getSchemeColor) per classificare un riempimento. Ad esempio, una porzione di testo può non avere un colore di schema definito localmente, quindi il suo valore locale è `NotDefined`, mentre il suo riempimento efficace eredita un colore del tema e si risolve in `Text1` o `Accent6`. Al contrario, `getSolidFillSchemeColor` indica quale slot logico del tema ha prodotto il colore efficace, ma non indica se quello slot provenga dall'oggetto, dal paragrafo, dal layout, dal master o da un altro livello della gerarchia di formattazione.

L'esempio seguente carica una presentazione, esamina sia i riempimenti di forma sia i riempimenti di porzioni di testo, stampa ogni valore RGB finale e il colore di schema associato, e segnala i riempimenti solidi che non seguiranno le modifiche ai colori del tema:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Il ramo `NotDefined` fornisce un elenco di audit di riempimenti solidi che non risponderanno alle modifiche negli slot di colore del tema. Rivedi quegli oggetti quando una presentazione deve adeguarsi a una nuova palette di brand. Il valore RGB segnalato mostra ancora l'aspetto corrente, mentre il valore di schema spiega se quell'aspetto è collegato al tema.

Gli oggetti di formato efficace sono istantanee. Dopo aver modificato il tema della presentazione, una sovrascrittura del tema o qualsiasi formattazione ereditata, chiama di nuovo `getEffective` e leggi un nuovo oggetto di dati di riempimento efficace prima di confrontare o segnalare i colori.

## **Leggere i valori efficaci del tema**

Gli oggetti tema grezzi indicano cosa è definito a un determinato livello. I valori efficaci indicano cosa una diapositiva o una forma utilizza realmente dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Per uno sfondo, usa [Background.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/#getEffective), e per un riempimento, usa [FillFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getEffective).

L'esempio seguente legge il tema efficace, lo sfondo e il primo riempimento di forma da una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Usa i dati efficaci per diagnostica di rendering, convalida e confronti. Se ispezioni solo [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasterTheme), potresti perdere un master, layout, diapositiva o sovrascrittura di forma che cambia l'aspetto finale.

## **FAQ**

**L'applicazione di un tema esterno influisce su ogni diapositiva della presentazione?**

No. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master mantengono i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidethememanager/) della diapositiva e inizializza la sua sovrascrittura del tema. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il metodo più sicuro per trasferire un tema da una presentazione a un'altra?**

Quando sposti una diapositiva e vuoi preservarne l'aspetto originale, clona il master di origine nella destinazione e clona la diapositiva con quel master usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslidecollection/#addClone) e [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone). Questo mantiene insieme il master, i layout e il tema.

**Come posso vedere i valori efficaci dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) per un tema di diapositiva o layout e i relativi metodi dei dati efficaci per oggetti di formato come [Background.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/background/#getEffective) e [FillFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getEffective). Queste API restituiscono i valori risolti dopo che sono state applicate ereditarietà e sovrascritture.